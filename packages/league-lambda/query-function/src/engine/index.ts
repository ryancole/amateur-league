export interface EngineConfig {}

export interface EngineRequest {
  path: string;
  method: string;
}

export function execute(config: EngineConfig, payload: EngineRequest): string {
  return "";
}
