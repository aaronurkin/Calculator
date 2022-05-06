import { IOperation } from '../operation.interface';
import { OperationInputDto } from '../dto/operation-input.dto';

export class MultiplicationOperation implements IOperation {
  public produce(inputDto: OperationInputDto): number {
    return inputDto.leftOperand * inputDto.rightOperand;
  }
}
