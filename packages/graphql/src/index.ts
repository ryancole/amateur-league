import { Handler } from "aws-lambda";
import { graphql } from "graphql";

import schema from "./schema";

export const handler: Handler = async (event, context) => {
  const result = await graphql(schema, event.body);
  return {
    body: JSON.stringify(result),
    headers: { "Content-Type": "application/json" }
  };
};
