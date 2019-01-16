import { GraphQLObjectType, GraphQLList } from "graphql";

import TeamType from "./TeamType";

import GetAllTeams from "../../database/team/get-all";

export default new GraphQLObjectType({
  name: "RootQuery",
  fields: {
    teams: {
      type: GraphQLList(TeamType),
      resolve: GetAllTeams
    }
  }
});
