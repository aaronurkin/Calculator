import { Test, TestingModule } from '@nestjs/testing';
import { IOperation } from '@services/application/operation';
import { OperationInputDto } from '@services/application/dto';
import { ServiceToken } from '@services/application/service-token';
import { ApplicationInfrastructureModule } from '@infrastructure/application/module';
import { SubtractionOperationProvider } from '@providers/subtraction-operation.provider';
import { SubtractionOperation } from '@infrastructure/application/operations/subtraction.operation';

describe(SubtractionOperation, () => {
  let operation: IOperation;

  beforeEach(async () => {
    const module: TestingModule = await Test.createTestingModule({
      providers: [SubtractionOperationProvider],
      imports: [ApplicationInfrastructureModule],
    }).compile();

    operation = module.get<IOperation>(`${ServiceToken.operation}-`);
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
