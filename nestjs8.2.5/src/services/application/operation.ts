import { OperationInputDto } from "./dto";

export interface IOperation {
    produce(inputDto: OperationInputDto): number;
}
