import { Test, TestingModule } from '@nestjs/testing';
import { IOperation } from '@services/application/operation';
import { OperationInputDto } from '@services/application/dto';
import { ServiceToken } from '@services/application/service-token';
import { DivisionOperationProvider } from '@providers/division-operation.provider';
import { ApplicationInfrastructureModule } from '@infrastructure/application/module';
import { DivisionOperation } from '@infrastructure/application/operations/division.operation';

describe(DivisionOperation, () => {
  let operation: IOperation;

  beforeEach(async () => {
    const module: TestingModule = await Test.createTestingModule({
      providers: [DivisionOperationProvider],
      imports: [ApplicationInfrastructureModule],
    }).compile();

    operation = await module.resolve<IOperation>(`${ServiceToken.operation}/`);
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
