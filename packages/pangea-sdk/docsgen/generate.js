const fs = require('fs');

const { XMLParser } = require("fast-xml-parser");
const sourceXMLPath = "source/PangeaCyber.Net.xml";
const destinationJSONPath = "./c#_sdk.json";

const parseEnumName = (namespace) => {
    const parts = namespace.split(":");
    if (parts.length === 2) {
        const qualifiedName = parts[1]
        const name = parts[1].split(".").pop();
        return { kind: "ENUM", qualifiedName, name, docComments: [] };
    }
};

const getEnums = (entries) => {
    let classes = [];
    entries.forEach(entry => {
        if (entry.kind === "enum" && "@_name" in entry) {
            const description = parseClassName(entry["@_name"]);
            if (description) {
                classes.push(description);
            }
        }
    });
    return classes;
};

const parseClassName = (namespace) => {
    const parts = namespace.split(":");
    if (parts.length === 2) {
        const qualifiedName = parts[1]
        const name = parts[1].split(".").pop();
        return { kind: "CLASS", qualifiedName, name, docComments: [] };
    }
};

const getClasses = (entries) => {
    let classes = [];
    entries.forEach(entry => {
        if (entry.kind === "class" && "@_name" in entry) {
            const classDescription = parseClassName(entry["@_name"]);
            if (classDescription) {
                classes.push(classDescription);
            }
        }
    });
    return classes;
};

const parseMethodName = (className, method) => {
    const parts = method.split(":");
    if (parts.length === 2) {
        const methodName = parts[1]
        return methodName?.replace(className + ".", "");
    }
};

/**
 * normalizeCodeExample - removes all the space chars after newlines
 * 
 * For some reason, pulling the example code from the XML
 * preserves the XML indentation level, so initially you get a string that
 * looks like: 
 * string msg = someCode;\n            var response = await moreCode();
 * 
 * To normalize everything, just replace the newline and 12 space chars
 * with ONE newline, so the above string becomes:
 * string msg = someCode;\nvar response = await moreCode();
 * 
 * @param {string} code 
 * @returns string
 */
const normalizeCodeExample = (code) => {
    if (typeof code === "undefined") return "";

    // The XML here has an indentation level of 12 spaces
    // Collapse those into one newline char
    return code.replace(/\n[ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]/g, "\n");
}

const getMethodsForClass = (entries, className) => {
    let methods = [];
    entries.forEach(entry => {
        if (entry.kind === "method" && entry?.["@_name"]?.indexOf(className) > -1) {
            const methodSignature = parseMethodName(className, entry["@_name"]);
            if (methodSignature) {
                const example = entry?.example?.code ? `{@code\n${entry?.example?.code}\n}` : null;
                const entryThrows = Array.isArray(entry?.exception) ? entry?.exception : [entry?.exception];

                const throws = entryThrows.map(ex => ({
                    tag: "@throws",
                    text: ex?.["@_cref"]?.split(":")?.[1]?.split(".").pop(),
                })) ?? [];

                const entryParams = Array.isArray(entry?.param) ? entry?.param : [entry?.param];

                const params = entryParams.map(p => ({
                    name: p?.["@_name"],
                    text: p?.["#text"],
                    type: p?.["@_type"]
                })) ?? [];

                const tags = [];
                const rawDocsArray = [entry?.remarks || "", `@pangea.description ${entry?.summary}`];

                if (entry?.summary) {
                    tags.push({
                        data: {
                            tag: "@pangea.description",
                            text: entry.summary,
                        },
                        rawText: `@pangea.description ${entry.summary}`,
                        kind: "UNKNOWN_BLOCK_TAG"
                    })
                }

                if (params.length > 0) {
                    tags.push(...(params.map(p => ({ rawText: `@param ${p.name} ${p.text}`, kind: "PARAM" }))));
                    rawDocsArray.push(...(params.map(p => `@param ${p.name} ${p.text}`)));
                }

                if (entry?.returns) {
                    tags.push({ rawText: `@return ${entry?.returns}`, kind: "RETURN" });
                    rawDocsArray.push(`@return ${entry.returns}`);
                }

                if (throws.length > 0) {
                    tags.push(...(throws.map(p => ({ rawText: `@throws ${p.text}`, kind: "THROWS" }))));
                    rawDocsArray.push(...(throws.map(t => `@throws ${t.text}`)));
                }

                if (entry?.operationid) {
                    tags.push({ rawText: `@operationId ${entry?.operationid}`, kind: "UNKNOWN_BLOCK_TAG" });
                    rawDocsArray.push(`@operationId ${entry.operationid}`);
                }

                if (example) {
                    tags.push({
                        data: {
                            tag: "@pangea.code",
                            text: example,
                        },
                        rawText: `@pangea.code ${example}`,
                        kind: "UNKNOWN_BLOCK_TAG"
                    });

                    rawDocsArray.push(`@pangea.code ${example}`);
                }

                // @TODO Add to array conditionally

                const method = {
                    "METHOD": methodSignature,
                    summary: entry?.remarks,
                    description: entry?.summary,
                    returns: entry?.returns,
                    // Add the operationId only if we have one
                    ...(entry?.operationid && {
                        operationId: entry.operationid,
                    }),
                    rawDocString: rawDocsArray.join("\n"),
                    throws,
                    params,
                    example,
                    // Add a normalized code example if we have example code
                    ...(entry?.example?.code && {
                        code: normalizeCodeExample(entry.example.code),
                    }),
                    tags,
                };

                methods.push(method);
            }
        }
    });
    return methods;
}

try {
    const results = [];
    const data = fs.readFileSync(sourceXMLPath, 'utf8');
    let content = new XMLParser({
        ignoreAttributes: false,
        trimValues: true,
    }).parse(data);
    const entries = content.doc.members.member;
    const classes = getClasses(entries);
    classes.forEach(c => {
        const methods = getMethodsForClass(entries, c.qualifiedName)
        c.docComments.push(...methods);
    });

    const enums = getEnums(entries);

    results.push(...enums);
    results.push(...classes);

    fs.writeFileSync(destinationJSONPath, JSON.stringify(results));
} catch (err) {
    console.error(err);
}

