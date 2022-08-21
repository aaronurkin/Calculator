import { Provider } from '@nestjs/common';
import { IOperationResponseResolver } from '@services/application/operation-response-resolver';
import { DefaultOperationResponseResolver } from '@infrastructure/application/default-operation-response.resolver';

export const OperationResponseResolverProvider: Provider<IOperationResponseResolver> =
  {
    provide: 'OPERATIONS_RESPONSE_RESOLVER',
    useClass: DefaultOperationResponseResolver,
  };
