import { ModuleRef } from "@nestjs/core";
import { Injectable } from "@nestjs/common";
import { IOperation } from "@services/application/operation";
import { IOperationsService } from "@services/application/operations.service";
import { OperationRequestDto, OperationResponseDto } from "@services/application/dto";
import { IOperationResponseResolver } from "@services/application/operation-response-resolver";

@Injectable()
export class OperationsService implements IOperationsService {
    constructor(private readonly moduleRef: ModuleRef) {}

    public async handle(requestDto: OperationRequestDto): Promise<OperationResponseDto> {
        const operation = await this.moduleRef.resolve<IOperation>(
            `OPERATION${requestDto.operation}`,
        );
    
        const operationResponseResolver = await this.moduleRef.resolve<IOperationResponseResolver>(
            `OPERATIONS_RESPONSE_RESOLVER${requestDto.responseType || ''}`,
        );
    
        const operationResult = operation.produce(requestDto);
        return operationResponseResolver.resolve(operationResult);
    }
}
