import { Provider } from '@nestjs/common';
import { IOperation } from '@services/application/operation';
import { ServiceToken } from '@services/application/service-token';
import { AdditionOperation } from '@infrastructure/application/operations/addition.operation';

export const AdditionOperationProvider: Provider<IOperation> = {
  provide: `${ServiceToken.operation}+`,
  useClass: AdditionOperation,
};
