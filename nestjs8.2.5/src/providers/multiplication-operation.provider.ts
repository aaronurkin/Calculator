import { Provider } from '@nestjs/common';
import { IOperation } from '@services/application/operation';
import { MultiplicationOperation } from '@infrastructure/application/operations/multiplication.operation';

export const MultiplicationOperationProvider: Provider<IOperation> = {
  provide: 'OPERATION*',
  useClass: MultiplicationOperation,
};
