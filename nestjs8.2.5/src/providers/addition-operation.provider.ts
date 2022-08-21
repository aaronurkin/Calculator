import { Provider } from '@nestjs/common';
import { IOperation } from '@services/application/operation';
import { AdditionOperation } from '@infrastructure/application/operations/addition.operation';

export const AdditionOperationProvider: Provider<IOperation> = {
  provide: 'OPERATION+',
  useClass: AdditionOperation,
};
