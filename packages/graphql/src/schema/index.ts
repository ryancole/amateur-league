import fs from "fs";
import path from "path";
import { buildSchema } from "graphql";

// our schema sdl exists on disk, so lets load that up
const sdlpath = path.resolve(__dirname, "../../../common/schema.gql");
const sdl = fs.readFileSync(sdlpath, { encoding: "utf8" });

// now we can export this schema
export default buildSchema(sdl);
