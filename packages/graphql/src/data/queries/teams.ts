import client from "../client";

export async function scanAll() {
  return await client.scan({
    TableName: "Teams"
  });
}
