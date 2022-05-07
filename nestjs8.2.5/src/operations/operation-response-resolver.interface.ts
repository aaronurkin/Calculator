import { OperationResponseDto } from './dto/operation-response.dto';

export interface IOperationResponseResolver {
  resolve(value: number): OperationResponseDto;
}
