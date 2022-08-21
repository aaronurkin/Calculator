import { OperationRequestDto, OperationResponseDto } from "./dto";

export interface IOperationsService {
    handle(requestDto: OperationRequestDto): Promise<OperationResponseDto>;
}
