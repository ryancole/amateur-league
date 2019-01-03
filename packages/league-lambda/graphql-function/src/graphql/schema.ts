import { GraphQLSchema } from "graphql";
import RootQueryType from "./type/RootQueryType";

export default new GraphQLSchema({
  query: RootQueryType
});
