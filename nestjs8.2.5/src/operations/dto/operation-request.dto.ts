import { OperationInputDto } from './operation-input.dto';

export interface OperationRequestDto extends OperationInputDto {
  operation: string;
  responseType: string;
}
