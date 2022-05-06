import { Test, TestingModule } from '@nestjs/testing';
import { DivisionOperation } from './division.operation';
import { IOperation } from '../operation.interface';
import { OperationInputDto } from '../dto/operation-input.dto';

describe(DivisionOperation, () => {
  let operation: IOperation;

  beforeEach(async () => {
    const module: TestingModule = await Test.createTestingModule({
      providers: [DivisionOperation],
    }).compile();

    operation = module.get<IOperation>(DivisionOperation);
  });

  it('should be defined', () => {
    expect(operation).toBeDefined();
  });

  it('should recieve 8 and 4 and return 2', () => {
    const dto: OperationInputDto = {
      leftOperand: 8,
      rightOperand: 4,
    };
    const result: number = operation.produce(dto);

    expect(result).not.toEqual(null);
    expect(result).toBe(2);
  });

  it('should recieve right operand 0 and throw Error', () => {
    const dto: OperationInputDto = {
      leftOperand: 8,
      rightOperand: 0,
    };
    const divideByZero = () => {
      operation.produce(dto);
    };

    expect(() => {
      divideByZero();
    }).toThrow(Error);

    expect(() => {
      divideByZero();
    }).toThrow('Right operand must not equal to 0');
  });
});
