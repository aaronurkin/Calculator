import { Module } from '@nestjs/common';
import { AdditionOperation } from './operations/addition.operation';
import { DivisionOperation } from './operations/division.operation';
import { SubtractionOperation } from './operations/subtraction.operation';
import { MultiplicationOperation } from './operations/multiplication.operation';

@Module({
    providers: [
        AdditionOperation,
        DivisionOperation,
        SubtractionOperation,
        MultiplicationOperation,
    ],
    exports: [
        AdditionOperation,
        DivisionOperation,
        SubtractionOperation,
        MultiplicationOperation,
    ],
})
export class ApplicationInfrastructureModule {}
