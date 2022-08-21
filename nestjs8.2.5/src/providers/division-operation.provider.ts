import { Provider, Scope } from '@nestjs/common';
import { IOperation } from '@services/application/operation';
import { ServiceToken } from '@services/application/service-token';
import { DivisionOperation } from '@infrastructure/application/operations/division.operation';

export const DivisionOperationProvider: Provider<IOperation> = {
  scope: Scope.REQUEST,
  provide: `${ServiceToken.operation}/`,
  useClass: DivisionOperation,
};
