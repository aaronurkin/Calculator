import { OperationResponseDto } from '../dto/operation-response.dto';
import { IOperationResponseResolver } from '../operation-response-resolver.interface';

export class DefaultOperationResponseResolver
  implements IOperationResponseResolver
{
  resolve(value: number): OperationResponseDto {
    return { value };
  }
}
