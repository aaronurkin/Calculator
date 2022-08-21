import { IOperation } from '@services/application/operation';
import { OperationInputDto } from '@services/application/dto';

export class SubtractionOperation implements IOperation {
  public produce(inputDto: OperationInputDto): number {
    if (!inputDto) {
      throw new Error(`Argument must be provided`);
    }

    return inputDto.leftOperand - inputDto.rightOperand;
  }
}
