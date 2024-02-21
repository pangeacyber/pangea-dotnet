import { expect, test, describe } from "vitest";

import { transform } from ".";

describe("transform()", () => {
  test("supports namespaces", () => {
    const actual = transform({
      items: [
        {
          commentId: "N:PangeaCyber.Net",
          fullName: "PangeaCyber.Net",
          id: "PangeaCyber.Net",
          name: "PangeaCyber.Net",
          nameWithType: "PangeaCyber.Net",
          type: "Namespace",
          uid: "PangeaCyber.Net",
        },
      ],
      references: [],
    });
    expect(actual.items.length).toEqual(1);
    expect(actual.items[0]).toMatchSnapshot();
  });

  test("supports classes", () => {
    const actual = transform({
      items: [
        {
          commentId: "T:PangeaCyber.Net.Vault.VaultClient",
          fullName: "PangeaCyber.Net.Vault.VaultClient",
          id: "VaultClient",
          name: "VaultClient",
          nameWithType: "VaultClient",
          parent: "PangeaCyber.Net.Vault",
          syntax: {
            content:
              "public class VaultClient : BaseClient<VaultClient.Builder>",
          },
          type: "Class",
          uid: "PangeaCyber.Net.Vault.VaultClient",
        },
      ],
      references: [],
    });
    expect(actual.items.length).toEqual(1);
    expect(actual.items[0]).toMatchSnapshot();
  });

  test("generic method parameters and return type are prettified", () => {
    const actual = transform({
      items: [
        {
          commentId:
            "M:PangeaCyber.Net.Vault.VaultClient.EncryptStructured``1(PangeaCyber.Net.Vault.Requests.EncryptStructuredRequest{``0},System.Threading.CancellationToken)",
          fullName:
            "PangeaCyber.Net.Vault.VaultClient.EncryptStructured<T>(PangeaCyber.Net.Vault.Requests.EncryptStructuredRequest<T>, System.Threading.CancellationToken)",
          id: "EncryptStructured``1(PangeaCyber.Net.Vault.Requests.EncryptStructuredRequest{``0},System.Threading.CancellationToken)",
          name: "EncryptStructured<T>(EncryptStructuredRequest<T>, CancellationToken)",
          nameWithType:
            "VaultClient.EncryptStructured<T>(EncryptStructuredRequest<T>, CancellationToken)",
          parent: "PangeaCyber.Net.Vault.VaultClient",
          type: "Method",
          uid: "PangeaCyber.Net.Vault.VaultClient.EncryptStructured``1(PangeaCyber.Net.Vault.Requests.EncryptStructuredRequest{``0},System.Threading.CancellationToken)",
          syntax: {
            content:
              "public Task<Response<EncryptStructuredResult<T>>> EncryptStructured<T>(EncryptStructuredRequest<T> request, CancellationToken cancellationToken = default)",
            parameters: [
              {
                id: "request",
                type: "PangeaCyber.Net.Vault.Requests.EncryptStructuredRequest{{T}}",
                description: "Request parameters.",
              },
              {
                id: "cancellationToken",
                type: "System.Threading.CancellationToken",
                description: "Cancellation token.",
              },
            ],
            typeParameters: [
              {
                id: "T",
                description: "Structured data type.",
              },
            ],
            return: {
              type: "System.Threading.Tasks.Task{PangeaCyber.Net.Response{PangeaCyber.Net.Vault.Results.EncryptStructuredResult{{T}}}}",
              description: "Encrypted result.",
            },
          },
        },
      ],
      references: [
        {
          uid: "PangeaCyber.Net.Vault.Requests.EncryptStructuredRequest{{T}}",
          nameWithType: "EncryptStructuredRequest<T>",
        },
        {
          uid: "System.Threading.CancellationToken",
          nameWithType: "CancellationToken",
        },
        {
          uid: "System.Threading.Tasks.Task{PangeaCyber.Net.Response{PangeaCyber.Net.Vault.Results.EncryptStructuredResult{{T}}}}",
          nameWithType: "Task<Response<EncryptStructuredResult<T>>>",
        },
      ],
    });
    expect(actual.items[0].syntax?.parameters?.[0].type).toEqual(
      "EncryptStructuredRequest<T>",
    );
    expect(actual.items[0].syntax?.return?.type).toEqual(
      "Task<Response<EncryptStructuredResult<T>>>",
    );
  });
});
