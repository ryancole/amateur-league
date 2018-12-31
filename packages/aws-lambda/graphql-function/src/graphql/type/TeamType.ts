import { GraphQLString, GraphQLObjectType } from "graphql";

export default new GraphQLObjectType({
  name: "TeamType",
  fields: {
    name: { type: GraphQLString }
  }
});
