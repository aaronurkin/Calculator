import { OperationInputDto } from './dto/operation-input.dto';

export interface IOperation {
  produce(inputDto: OperationInputDto): number;
}
