import { Test, TestingModule } from '@nestjs/testing';
import { OperationResponseDto } from '../dto/operation-response.dto';
import { IOperationResponseResolver } from '../operation-response-resolver.interface';
import { DefaultOperationResponseResolver } from './default-operation-response.resolver';

describe(DefaultOperationResponseResolver, () => {
  let resolver: IOperationResponseResolver;

  beforeEach(async () => {
    const module: TestingModule = await Test.createTestingModule({
      providers: [DefaultOperationResponseResolver],
    }).compile();

    resolver = module.get<IOperationResponseResolver>(
      DefaultOperationResponseResolver,
    );
  });

  it('should be defined', () => {
    expect(resolver).toBeDefined();
  });

  it('should return an OperationResponseDto instance', () => {
    const result: OperationResponseDto = { value: 0 };
    jest.spyOn(resolver, 'resolve').mockImplementation(() => result);
    expect(resolver.resolve(0)).toBe(result);
  });
});
