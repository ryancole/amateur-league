import { GraphQLString, GraphQLObjectType } from "graphql";

export default new GraphQLObjectType({
  name: "Team",
  fields: {
    name: { type: GraphQLString }
  }
});
