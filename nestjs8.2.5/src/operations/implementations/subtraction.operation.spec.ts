import { Test, TestingModule } from '@nestjs/testing';
import { IOperation } from '../operation.interface';
import { OperationInputDto } from '../dto/operation-input.dto';
import { SubtractionOperation } from './subtraction.operation';

describe(SubtractionOperation, () => {
  let operation: IOperation;

  beforeEach(async () => {
    const module: TestingModule = await Test.createTestingModule({
      providers: [SubtractionOperation],
    }).compile();

    operation = module.get<IOperation>(SubtractionOperation);
  });

  it('should be defined', () => {
    expect(SubtractionOperation).toBeDefined();
  });

  it('should recieve 3 and 5 and return 2', () => {
    const dto: OperationInputDto = {
      leftOperand: 5,
      rightOperand: 3,
    };
    const result: number = operation.produce(dto);

    expect(result).not.toEqual(null);
    expect(result).toBe(2);
  });
});
