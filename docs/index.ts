interface TypeParameter {
  description: string;
  id: string;
}

interface Parameter {
  description: string;
  id: string;
  type: string;
}

interface Return {
  description: string;
  type: string;
}

interface Syntax {
  content: string;
  parameters?: Parameter[];
  return?: Return;
  typeParameters?: TypeParameter[];
}

interface Item {
  commentId: string;
  example?: string[];
  fullName: string;
  id: string;
  name: string;
  nameWithType: string;
  parent?: string;
  remarks?: string;
  source?: { id: string }
  summary?: string;
  syntax?: Syntax;
  type: "Class" | "Constructor" | "Enum" | "Field" | "Method" | "Namespace" | "Property";
  uid: string;
}

interface Reference {
  uid: string;
  nameWithType: string;
}

export interface Metadata {
  items: Item[];
  references: Reference[];
}

function transformType<T extends { type: string }>(
  typed: T,
  references: readonly Reference[],
): T {
  const reference = references.find(({ uid }) => uid === typed.type);
  if (!reference) {
    throw new Error(`Could not find reference for type '${typed.type}'.`);
  }

  return {
    ...typed,
    type: reference.nameWithType,
  };
}

function transformSyntax(
  syntax: Readonly<Syntax>,
  references: readonly Reference[],
): Syntax {
  return {
    content: syntax.content,
    parameters: syntax.parameters
      ? syntax.parameters.map((x) => transformType(x, references))
      : undefined,
    return: syntax.return
      ? transformType(syntax.return, references)
      : undefined,
    typeParameters: syntax.typeParameters,
  };
}

function transformItem(
  item: Readonly<Item>,
  references: readonly Reference[],
): Item {
  // Spread operator isn't used so that extraneous properties like the VB.NET
  // ones aren't included.
  return {
    commentId: item.commentId,
    example: item.example,
    fullName: item.fullName,
    id: item.id,
    name: item.name,
    nameWithType: item.nameWithType,
    parent: item.parent,
    remarks: item.remarks,
    source: item.source ? { id: item.source.id } : undefined,
    summary: item.summary,
    syntax: item.syntax ? transformSyntax(item.syntax, references) : undefined,
    type: item.type,
    uid: item.uid,
  };
}

export function transform(metadata: Readonly<Metadata>): Metadata {
  return {
    items: metadata.items.map((x) => transformItem(x, metadata.references)),

    // Empty the references since they have already served their purpose.
    references: [],
  };
}
