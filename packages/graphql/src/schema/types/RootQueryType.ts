import { GraphQLObjectType, GraphQLString } from "graphql";

export default new GraphQLObjectType({
  name: "RootQuery",
  fields: {
    hello: { type: GraphQLString, resolve: () => "hello!!!!" }
  }
});
