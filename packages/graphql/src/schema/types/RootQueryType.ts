import { GraphQLList, GraphQLObjectType } from "graphql";

import TeamType from "./TeamType";

import * as TeamDb from "../../data/queries/teams";

export default new GraphQLObjectType({
  name: "RootQuery",
  fields: {
    teams: { type: GraphQLList(TeamType), resolve: () => TeamDb.scanAll() }
  }
});
