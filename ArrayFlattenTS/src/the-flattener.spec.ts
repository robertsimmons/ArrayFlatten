import TheFlattener from './the-flattener';

describe('TheFlattener', () => {

    let sut: TheFlattener;

    beforeEach(() => {
        sut = new TheFlattener();
    });

    describe('flattenize', () => {
        it('should flatten the example', () => {
            expect(sut.flattenize([[1,2,[3]],4])).toEqual([1,2,3,4]);
        });
        
        it('should flatten a deep empty array', () => {
            expect(sut.flattenize([[[[]]]])).toEqual([]);
        });
        
        it('should flatten null', () => {
            expect(sut.flattenize(<any>null)).toEqual([]);
        });
        
        it('should flatten weirdly nested arrays', () => {
            expect(sut.flattenize([[[3,4,[1,2]]]])).toEqual([3,4,1,2]);
        });
    });

    describe('flattenize with reduce', () => {
        it('should flatten the example', () => {
            expect(sut.flattenizeWithReduce([[1,2,[3]],4])).toEqual([1,2,3,4]);
        });
        
        it('should flatten a deep empty array', () => {
            expect(sut.flattenizeWithReduce([[[[]]]])).toEqual([]);
        });
        
        it('should flatten null', () => {
            expect(sut.flattenizeWithReduce(<any>null)).toEqual([]);
        });
        
        it('should flatten weirdly nested arrays', () => {
            expect(sut.flattenizeWithReduce([[[3,4,[1,2]]]])).toEqual([3,4,1,2]);
        });
    });
});