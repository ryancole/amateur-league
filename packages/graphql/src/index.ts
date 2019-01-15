import { graphql } from "graphql";
import { AzureFunction, HttpRequest } from "@azure/functions";

import schema from "./schema";
import resolver from "./schema/resolver";

export const run: AzureFunction = async (context, req: HttpRequest) => {
  const result = await graphql(schema, req.body, resolver);
  return { body: JSON.stringify(result) };
};
