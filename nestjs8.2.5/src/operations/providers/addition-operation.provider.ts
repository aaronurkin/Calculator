import { Provider } from '@nestjs/common';
import { IOperation } from '../operation.interface';
import { AdditionOperation } from '../implementations/addition.operation';

export const AdditionOperationProvider: Provider<IOperation> = {
  provide: 'OPERATION+',
  useClass: AdditionOperation,
};
