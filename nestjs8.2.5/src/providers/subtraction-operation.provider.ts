import { Provider } from '@nestjs/common';
import { IOperation } from '@services/application/operation';
import { SubtractionOperation } from '@infrastructure/application/operations/subtraction.operation';

export const SubtractionOperationProvider: Provider<IOperation> = {
  provide: 'OPERATION-',
  useClass: SubtractionOperation,
};
