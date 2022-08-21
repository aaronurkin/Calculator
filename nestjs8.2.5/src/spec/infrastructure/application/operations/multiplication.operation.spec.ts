import { Test, TestingModule } from '@nestjs/testing';
import { IOperation } from '@services/application/operation';
import { OperationInputDto } from '@services/application/dto';
import { ServiceToken } from '@services/application/service-token';
import { ApplicationInfrastructureModule } from '@infrastructure/application/module';
import { MultiplicationOperationProvider } from '@providers/multiplication-operation.provider';
import { MultiplicationOperation } from '@infrastructure/application/operations/multiplication.operation';

describe(MultiplicationOperation, () => {
  let operation: IOperation;

  beforeEach(async () => {
    const module: TestingModule = await Test.createTestingModule({
      providers: [MultiplicationOperationProvider],
      imports: [ApplicationInfrastructureModule],
    }).compile();

    operation = await module.resolve<IOperation>(`${ServiceToken.operation}*`);
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
