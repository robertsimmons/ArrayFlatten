export default class TheFlattener {
    flattenize(input: any[]): number[] {
        let numbers: number[] = [];

        if (!input) {
            return numbers;
        }

        for (let i = 0; i < input.length; i++) {
            if (Array.isArray(input[i])) {
                numbers = numbers.concat(this.flattenize(<[]>input[i]));
            } else {
                numbers.push(<number>input[i]);
            }
        }

        return numbers;
    }

    flattenizeWithReduce(input: any[]): number[] {
        if (!input) {
            return [];
        }
        
        return input.reduce((acc: number[], current: number | any[]) => {
            if (Array.isArray(current)) {
                return acc.concat(this.flattenizeWithReduce(<[]>current));
            }
            
            acc.push(current);
            return acc;
        }, []);
    }
}