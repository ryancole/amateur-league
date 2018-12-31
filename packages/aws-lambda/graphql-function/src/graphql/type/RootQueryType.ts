import { GraphQLList, GraphQLObjectType } from "graphql";

import TeamType from "./TeamType";

import * as TeamApi from "../../dynamodb/team";

export default new GraphQLObjectType({
  name: "RootQueryType",
  fields: {
    teams: {
      type: new GraphQLList(TeamType),
      resolve: TeamApi.fetchAll
    }
  }
});
