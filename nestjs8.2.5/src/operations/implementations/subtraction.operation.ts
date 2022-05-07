import { IOperation } from '../operation.interface';
import { OperationInputDto } from '../dto/operation-input.dto';

export class SubtractionOperation implements IOperation {
  public produce(inputDto: OperationInputDto): number {
    return inputDto.leftOperand - inputDto.rightOperand;
  }
}
