import { Test, TestingModule } from '@nestjs/testing';
import { IOperation } from '../operation.interface';
import { AdditionOperation } from './addition.operation';
import { OperationInputDto } from '../dto/operation-input.dto';

describe(AdditionOperation, () => {
  let operation: IOperation;

  beforeEach(async () => {
    const module: TestingModule = await Test.createTestingModule({
      providers: [AdditionOperation],
    }).compile();

    operation = module.get<IOperation>(AdditionOperation);
  });

  it('should be defined', () => {
    expect(operation).toBeDefined();
  });

  it('should recieve 3 and 5 and return 8', () => {
    const dto: OperationInputDto = {
      leftOperand: 5,
      rightOperand: 3,
    };
    const result: number = operation.produce(dto);

    expect(result).not.toEqual(null);
    expect(result).toBe(8);
  });
});
