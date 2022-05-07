import { IOperation } from '../operation.interface';
import { OperationInputDto } from '../dto/operation-input.dto';

export class DivisionOperation implements IOperation {
  public produce(inputDto: OperationInputDto): number {
    if (inputDto.rightOperand == 0) {
      throw new Error('Right operand must not equal to 0');
    }
    return inputDto.leftOperand / inputDto.rightOperand;
  }
}
