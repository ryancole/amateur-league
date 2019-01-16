import { GraphQLSchema } from "graphql";
import RootQueryType from "./types/RootQueryType";

export default new GraphQLSchema({
  query: RootQueryType
});
