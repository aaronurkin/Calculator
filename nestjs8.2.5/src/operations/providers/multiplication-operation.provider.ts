import { Provider } from '@nestjs/common';
import { IOperation } from '../operation.interface';
import { MultiplicationOperation } from '../implementations/multiplication.operation';

export const MultiplicationOperationProvider: Provider<IOperation> = {
  provide: 'OPERATION*',
  useClass: MultiplicationOperation,
};
