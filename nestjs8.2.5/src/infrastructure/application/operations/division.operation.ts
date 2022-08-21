import { IOperation } from '@services/application/operation';
import { OperationInputDto } from '@services/application/dto';

export class DivisionOperation implements IOperation {
  public produce(inputDto: OperationInputDto): number {
    if (!inputDto) {
      throw new Error(`Argument must be provided`);
    }

    if (inputDto.rightOperand == 0) {
      throw new Error(`Right operand must not equal to 0`);
    }

    return inputDto.leftOperand / inputDto.rightOperand;
  }
}
