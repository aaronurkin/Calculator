import { Provider } from '@nestjs/common';
import { IOperationsService } from '@services/application/operations.service';
import { OperationsService } from '@infrastructure/application/operations.service';

export const OperationsServiceProvider: Provider<IOperationsService> = {
  provide: 'OPERATION_SERVICE',
  useClass: OperationsService,
};
