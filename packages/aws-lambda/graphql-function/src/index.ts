import {
  graphql,
  GraphQLSchema,
  GraphQLString,
  GraphQLObjectType
} from "graphql";

const RootQueryType = new GraphQLObjectType({
  name: "RootQueryType",
  fields: {
    hello: {
      type: GraphQLString,
      resolve: () => "Hello World!"
    }
  }
});

const schema = new GraphQLSchema({
  query: RootQueryType
});

export const handler: AWSLambda.Handler = async (event, context, callback) => {
  const result = await graphql(schema, event.body);
  const response = {
    body: JSON.stringify(result),
    headers: { "Content-Type": "application/json" }
  };
  callback(null, response);
};
