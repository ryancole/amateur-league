import { graphql } from "graphql";
import { AzureFunction, HttpRequest } from "@azure/functions";

import schema from "./schema";

export const run: AzureFunction = async (context, req: HttpRequest) => {
  const result = await graphql(schema, req.body);
  return { body: JSON.stringify(result) };
};
