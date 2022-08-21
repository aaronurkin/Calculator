import { OperationResponseDto } from "./dto";

export interface IOperationResponseResolver {
    resolve(value: number): OperationResponseDto;
}
  