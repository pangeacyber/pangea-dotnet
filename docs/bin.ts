import { readFile } from "node:fs/promises";
import { resolve } from "node:path";

import { XMLParser } from "fast-xml-parser";
import { load } from "js-yaml";

import { type Metadata, transform } from "./index";

interface XmlMember {
  "@_name": string;
  operationid?: string;
}

async function main() {
  const rawManifest = await readFile(
    resolve(__dirname, "out", "api", ".manifest"),
    { encoding: "utf8" },
  );
  const manifest: Record<string, string> = JSON.parse(rawManifest);

  const results: Metadata[] = [];
  for (const file of new Set(Object.values(manifest))) {
    const rawMetadata = await readFile(resolve(__dirname, "out", "api", file), {
      encoding: "utf8",
    });
    const metadata = load(rawMetadata) as Metadata;
    results.push(metadata);
  }

  const rawXmlDocs = await readFile(
    resolve(
      __dirname,
      "../packages/pangea-sdk/PangeaCyber.Net/bin/Release/net6.0/PangeaCyber.Net.xml",
    ),
    { encoding: "utf8" },
  );
  const xmlDocs = new XMLParser({
    ignoreAttributes: false,
    trimValues: true,
  }).parse(rawXmlDocs);
  const xmlMembers: readonly XmlMember[] = xmlDocs.doc.members.member;

  const items = results
    .map(transform)
    .flatMap(({ items }) => items)
    .map((item) => {
      // Only methods should have operation IDs. Return early for anything else.
      if (item.type !== "Method") {
        return item;
      }

      const xmlMember = xmlMembers.find(
        (xmlItem) => xmlItem["@_name"] === item.commentId,
      );
      if (!xmlMember) {
        console.warn(
          `Could not find a corresponding XML member for item '${item.uid}'.`,
        );
        return item;
      }
      return {
        ...item,
        operationId: xmlMember.operationid,
      };
    });

  console.log(JSON.stringify(items, null, 2));
}

main();
