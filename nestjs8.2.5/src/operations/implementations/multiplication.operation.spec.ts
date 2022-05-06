import { Test, TestingModule } from '@nestjs/testing';
import { IOperation } from '../operation.interface';
import { OperationInputDto } from '../dto/operation-input.dto';
import { MultiplicationOperation } from './multiplication.operation';

describe(MultiplicationOperation, () => {
  let operation: IOperation;

  beforeEach(async () => {
    const module: TestingModule = await Test.createTestingModule({
      providers: [MultiplicationOperation],
    }).compile();

    operation = module.get<IOperation>(MultiplicationOperation);
  });

  it('should be defined', () => {
    expect(MultiplicationOperation).toBeDefined();
  });

  it('should recieve 3 and 5 and return 15', () => {
    const dto: OperationInputDto = {
      leftOperand: 5,
      rightOperand: 3,
    };
    const result: number = operation.produce(dto);

    expect(result).not.toEqual(null);
    expect(result).toBe(15);
  });
});
