import { Provider } from '@nestjs/common';
import { IOperation } from '@services/application/operation';
import { ServiceToken } from '@services/application/service-token';
import { SubtractionOperation } from '@infrastructure/application/operations/subtraction.operation';

export const SubtractionOperationProvider: Provider<IOperation> = {
  provide: `${ServiceToken.operation}-`,
  useClass: SubtractionOperation,
};
