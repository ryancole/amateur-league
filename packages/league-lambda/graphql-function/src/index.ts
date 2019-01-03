import { graphql } from "graphql";
import schema from "./graphql/schema";

export const handler: AWSLambda.Handler = async event => {
  // execute the graphql query
  const result = await graphql(schema, event.body);

  // format lambda response
  const response = {
    body: JSON.stringify(result),
    headers: { "Content-Type": "application/json" }
  };

  // forward the response to lambda host
  return response;
};
