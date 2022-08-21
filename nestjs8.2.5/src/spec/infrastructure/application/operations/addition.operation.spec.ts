import { Test, TestingModule } from '@nestjs/testing';
import { IOperation } from '@services/application/operation';
import { OperationInputDto } from '@services/application/dto';
import { ServiceToken } from '@services/application/service-token';
import { AdditionOperationProvider } from '@providers/addition-operation.provider';
import { ApplicationInfrastructureModule } from '@infrastructure/application/module';
import { AdditionOperation } from '@infrastructure/application/operations/addition.operation';

describe(AdditionOperation, () => {
  let operation: IOperation;

  beforeEach(async () => {
    const module: TestingModule = await Test.createTestingModule({
      providers: [AdditionOperationProvider],
      imports: [ApplicationInfrastructureModule],
    }).compile();

    operation = await module.resolve<IOperation>(`${ServiceToken.operation}+`);
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
