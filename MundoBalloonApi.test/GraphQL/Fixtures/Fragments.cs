namespace MundoBalloonApi.test.GraphQL.Fixtures;

public static class Fragments
{
    private static string ProductSimpleCard = @"
        fragment CategoryName on ProductCategory {
            name
        }

        fragment MediaUrlAndType on ProductVariantMedium {
            url
            mediaType
        }

        fragment ProductVariantsMediaOnly on ProductVariant {
            media {
                ...MediaUrlAndType
            }
        }

        fragment ProductSimpleCard on Product {
            productId
            name
            category {
                ...CategoryName
            }
            price
            variants {
                ...ProductVariantsMediaOnly
            }
        }
    ";

    public static string ProductsDictionaryFragment = Fragments.ProductSimpleCard + @"
        fragment ProductsDictionary on KeyValuePairOfStringAndListOfProduct {
          key
          value {
            ...ProductSimpleCard
          }
        }
    ";
}