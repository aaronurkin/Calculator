import { OperationResponseDto } from "@services/application/dto";
import { IOperationResponseResolver } from "@services/application/operation-response-resolver";

export class DefaultOperationResponseResolver implements IOperationResponseResolver {
  resolve(value: number): OperationResponseDto {
    return { value };
  }
}
