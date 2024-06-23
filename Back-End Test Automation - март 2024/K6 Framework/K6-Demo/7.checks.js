import http from 'k6/http';
import { sleep, check } from 'k6';

export default function () {
    const response = http.get('https://test.k6.io');
    check(response, {
        'HTTP request is 200': (r) => r.status === 200,
        'Homepage has welcome header': (r) => r.body.includes("Welcome to the k6.io demo site!")
    });
    sleep(1);    
}